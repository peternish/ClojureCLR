;   Copyright (c) David Miller. All rights reserved.
;   The use and distribution terms for this software are covered by the
;   Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
;   which can be found in the file epl-v10.html at the root of this distribution.
;   By using this software in any fashion, you are agreeing to be bound by
;   the terms of this license.
;   You must not remove this notice, or any other, from this software.


(ns clojure.test)

; check generation of boolean test when test is known to be of type bool.

(defn test-if [i n] ( if (> i n) 'a 'b))

; check generation of boolean test when test type is not known.

(defn test-if2-test [i n] (> i n))
(defn test-if2 [i n]  (if (test-if2-test i n) 'a 'b))

; check generation of boolean test when return type is not bool.
(defn test-if3 [i n] (if i n 'b))


(defn f1 [l n] (if (> (count l) n) nil (recur (cons 'a l) n)))
(defn len [x]
  (. x Length))
(defn len2 [#^String x]
  (. x Length))

(defn test1 [] (time (f1 nil 10000)))
(defn test2 [] (time (reduce + (map len (replicate 10000 "asdf")))))
(defn test3 [] (time (reduce + (map len2 (replicate 10000 "asdf")))))

(defn f2 [n] (dotimes [i n] (list i)))

(defn test4[] (time (f2 100000)))


