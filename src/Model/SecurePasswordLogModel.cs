using System.Collections.Generic;

namespace Trendyol.TyMiddleware
{
    public class SecurePasswordLogModel
    {
        public bool SecurePasswordLogEnabled { get; set; }
        public bool CaseSensitiveEnabled { get; set; }
        public List<string> PasswordFieldNames { get; set; }
    }
}