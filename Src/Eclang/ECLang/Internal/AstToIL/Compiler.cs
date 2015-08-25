using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using ECLang.AST;
using ECLang.AST.Statements;
using ECLang.Internal.Primitives;

namespace ECLang.Internal.AstToIL
{
    public class Compiler
    {
        private AssemblyBuilder asm;


        public void BuildLi(List<CodeBlock> CodeBlocks, string asmname)
        {
            //setup
            asm = AppDomain.CurrentDomain.DefineDynamicAssembly(
                new AssemblyName(asmname), AssemblyBuilderAccess.Save);
            ModuleBuilder mod = asm.DefineDynamicModule("TestOutput.exe",
               asmname +".exe");
            TypeBuilder type = mod.DefineType("Program", TypeAttributes.Class);
            MethodBuilder main = type.DefineMethod("Main",
               MethodAttributes.Public | MethodAttributes.Static);
            ILGenerator il = main.GetILGenerator();
            //actual il code

            foreach (var block in CodeBlocks)
            {
                if (block.name == "ClassCode")
                {
                    foreach (IAst node in block.Nodes)
                    {
                        if (node is ObjCallStmt)
                        {
                            ObjCallStmt nd = node as ObjCallStmt;
                            il.Emit(OpCodes.Ldstr, (nd.Paramaters[0] as EcString).Value as string);
                        }

                    }

                    break;
                }

            }

            /*  il.Emit(OpCodes.Ldstr, "Hello world!");
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine",
                BindingFlags.Public | BindingFlags.Static,
                null, new Type[] { typeof(String) }, null));*/
            il.Emit(OpCodes.Ret);


            //done
            type.CreateType();
            asm.SetEntryPoint(main);
            

          
        }

        public void SaveExe(string path)
        {
            asm.Save(path);
        }


       
    }
}
