using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core
{
    public abstract class Scanner
    {
        protected List<Type> expressionTypes;

        public Scanner()
        {
            expressionTypes = Assembly.GetCallingAssembly()
                            .GetTypes()
                            .Where(t => typeof(IExpression).IsAssignableFrom(t))
                            .OrderBy(t => t.GetCustomAttribute<ExpressionAttribute>()?.Order ?? 0)
                            .ToList();
        }

        public virtual bool TryScan<T>(TokenStream syntaxStream, out T scanResult)
            where T : Syntax, new()
        {
            scanResult = new T();
            return scanResult.TryParse(syntaxStream, this);
        }
        public virtual bool TryScan(TokenStream syntaxStream, Type type, out Syntax scanResult)
        {
            scanResult = (Syntax)Activator.CreateInstance(type);
            return scanResult.TryParse(syntaxStream, this);
        }

        public virtual bool TryGetExpression(TokenStream syntaxStream, out IExpression expression)
        {
            expression = null;

            foreach (var type in expressionTypes)
            {
                if (TryScan(syntaxStream, type, out Syntax result))
                {
                    expression = (IExpression)result;
                    return true;
                }
            }

            return false;
        }
    }
}
