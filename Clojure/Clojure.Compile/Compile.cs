﻿/**
 *   Copyright (c) Rich Hickey. All rights reserved.
 *   The use and distribution terms for this software are covered by the
 *   Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
 *   which can be found in the file epl-v10.html at the root of this distribution.
 *   By using this software in any fashion, you are agreeing to be bound by
 * 	 the terms of this license.
 *   You must not remove this notice, or any other, from this software.
 **/

/**
 *   Author: David Miller
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using clojure.lang;
using System.Collections;
using System.Diagnostics;

namespace BootstrapCompile
{
    static class Compile
    {

        const string PATH_PROP = "clojure.compile.path";
        const string REFLECTION_WARNING_PROP = "clojure.compile.warn-on-reflection";

        static void Main(string[] args)
        {
            TextWriter outTW = (TextWriter)RT.OUT.deref();
            TextWriter errTW = RT.errPrintWriter();

            string path = Environment.GetEnvironmentVariable(PATH_PROP);
            // TODO: get rid of this when we have the full build process set up
            path = path ?? ".";

            if ( path == null )
            {
                errTW.WriteLine("ERROR: Must set system property {0}",PATH_PROP);
                errTW.WriteLine("to the location for the compiled .class files.");
                errTW.WriteLine("This directory must also be on your {0}.",RT.CLOJURE_LOAD_PATH);
                Environment.Exit(1);
            }

            string warnVal =  Environment.GetEnvironmentVariable(REFLECTION_WARNING_PROP);
            bool warnOnReflection = warnVal == null ? false : warnVal.Equals(true);

            try 
            {
                Var.pushThreadBindings(RT.map(
                    Compiler.COMPILE_PATH,path,
                    RT.WARN_ON_REFLECTION,warnOnReflection
                    ));

                Stopwatch sw = new Stopwatch();

                foreach ( string lib in args )
                {
                    sw.Reset();
                    sw.Start();
                    outTW.Write("Compiling {0} to {1}",lib,path);
                    outTW.Flush();
                    Compiler.COMPILE.invoke(Symbol.intern(lib));
                    sw.Stop();
                    outTW.WriteLine(" -- {0} milliseconds.", sw.ElapsedMilliseconds);
                }
            }
            finally
            {
                Var.popThreadBindings();
                try {
                    outTW.Flush();
                    outTW.Close();
                }
                catch ( IOException e)
                {
                    errTW.WriteLine(e.StackTrace);
                }
            }

               
    
        }
    }
}
