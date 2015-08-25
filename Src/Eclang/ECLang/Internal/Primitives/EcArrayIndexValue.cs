using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECLang.Internal.Primitives.Base;
using ECLang.Internal.Tables;

namespace ECLang.Internal.Primitives
{
    public class EcArrayIndexValue: Primitive
    {
        

        public EcArrayIndexValue()
        {
            this.Name = "EcArrayIndexValue";
        }

        public EcArrayIndexValue(string src)
        {
            this.Name = "EcArrayIndexValue";
        }

        public override Primitive Parse(object src)
        {
            return new EcString(src as string, false);
        }

        public override bool Validate(object src)
        {
            var l = (src as string).Split('[').Length;
            return l >= 2 && SymbolTable.Contains((src as string).Split('[')[0]);
        }
    }
}
