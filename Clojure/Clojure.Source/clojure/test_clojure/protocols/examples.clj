﻿(ns clojure.test-clojure.protocols.examples)

(defprotocol AnExampleProtocol
  "example protocol used by clojure tests"

  (foo [a] "method with one arg")
  (bar [a b] "method with two args")
  (baz [a] [a b] "method with multiple arities")
  (with-quux [a] "method name with a hyphen"))

