﻿;   Copyright (c) Rich Hickey. All rights reserved.
;   The use and distribution terms for this software are covered by the
;   Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
;   which can be found in the file epl-v10.html at the root of this distribution.
;   By using this software in any fashion, you are agreeing to be bound by
;   the terms of this license.
;   You must not remove this notice, or any other, from this software.

; Author: Stuart Halloway

(ns clojure.test-clojure.protocols
  (:use clojure.test clojure.test-clojure.protocols.examples)
  (:require [clojure.test-clojure.protocols.more-examples :as other]))

;; temporary hack until I decide how to cleanly reload protocol
(defn reload-example-protocols
  []
  (alter-var-root #'clojure.test-clojure.protocols.examples/ExampleProtocol
                  assoc :impls {})
  (alter-var-root #'clojure.test-clojure.protocols.more-examples/SimpleProtocol
                  assoc :impls {})
  (require :reload
           'clojure.test-clojure.protocols.examples
           'clojure.test-clojure.protocols.more-examples))

(defn method-names
  "return sorted list of method names on a class"
  [c]
  (->> (.GetMethods c)                       ;;; getMethods
     (map #(.Name %))                        ;;; getName
     (sort)))

(deftest protocols-test
  (testing "protocol fns throw IllegalArgumentException if no impl matches"
    (is (thrown-with-msg?
          IllegalArgumentException
          #"No implementation of method: :foo of protocol: #'clojure.test-clojure.protocols.examples/ExampleProtocol found for class: java.lang.Integer"
          (foo 10))))
  (testing "protocols generate a corresponding interface using _ instead of - for method names"
    (is (= ["bar" "baz" "baz" "foo" "with_quux"] (method-names clojure.test_clojure.protocols.examples.ExampleProtocol))))
  (testing "protocol will work with instances of its interface (use for interop, not in Clojure!)"
    (let [obj (proxy [clojure.test_clojure.protocols.examples.ExampleProtocol] []
                (foo [] "foo!"))]
      (is (= "foo!" (.foo obj)) "call through interface")
      (is (= "foo!" (foo obj)) "call through protocol")))
;;;  (testing "you can implement just part of a protocol if you want"
;;;    (let [obj (reify ExampleProtocol
;;;                     (baz [a b] "two-arg baz!"))]
;;;      (is (= "two-arg baz!" (baz obj nil)))
;;;      (is (thrown? AbstractMethodError (baz obj))))))
)
(deftest extend-test
  (testing "you can extend a protocol to a class"
    (extend String ExampleProtocol
            {:foo identity})
    (is (= "pow" (foo "pow"))))
  (testing "you can have two methods with the same name. Just use namespaces!"
    (extend String other/SimpleProtocol
     {:foo (fn [s] (.toUpperCase s))})
    (is (= "POW" (other/foo "pow"))))
  (testing "you can extend deftype types"
    (deftype Widget [name])
    (extend
     ::Widget
     ExampleProtocol
     {:foo (fn [this] (str "widget " (:name this)))})
    (is (= "widget z" (foo (Widget "z"))))))

(deftest extends?-test
  (reload-example-protocols)
  (deftype Whatzit []
    ExampleProtocol)
  (testing "returns nil if a type does not implement the protocol at all"
    (is (nil? (extends? other/SimpleProtocol ::Whatzit))))
  (testing "returns nil if a type implements the protocol directly" ;; TBD false?
    (is (nil? (extends? ExampleProtocol ::Whatzit))))
  (testing "returns true if a type explicitly extends protocol"
    (extend
     ::Whatzit
     other/SimpleProtocol
     {:foo identity})
    (is (true? (extends? other/SimpleProtocol ::Whatzit)))))

(deftest extenders-test
  (reload-example-protocols)
  (testing "a fresh protocol has no extenders"
    (is (nil? (extenders ExampleProtocol))))
  (testing "extending with no methods doesn't count!"
    (deftype Something [])
    (extend ::Something ExampleProtocol)
    (is (nil? (extenders ExampleProtocol))))
  (testing "extending a protocol (and including an impl) adds an entry to extenders"
    (deftype Whatzit [])
    (extend ::Whatzit ExampleProtocol {:foo identity})
    (is (= [::Whatzit] (extenders ExampleProtocol)))))

(deftest satisifies?-test
  (reload-example-protocols)
  (deftype Whatzit []
    ExampleProtocol)
  (let [whatzit (Whatzit)]
    (testing "returns nil if a type does not implement the protocol at all"
      (is (nil? (satisfies? other/SimpleProtocol whatzit))))
    (testing "returns true if a type implements the protocol directly"
      (is (true? (satisfies? ExampleProtocol whatzit))))
    (testing "returns true if a type explicitly extends protocol"
      (extend
       ::Whatzit
       other/SimpleProtocol
       {:foo identity})
      (is (true? (satisfies? other/SimpleProtocol whatzit)))))  )

;; todo
;; what happens if you extend after implementing directly?
;; investigate how nil-handling changes error handling
;; extend-type extend-protocol extend-class
;; maybe: find-protocol-impl find-protocol-method
;; deftype, printable forms
;; reify, definterface