using System.Collections.Generic;
using System.Security.Claims;

namespace modelo_core_angular.Models
{
    public class UsuarioClaims
    {
        public UsuarioClaims(Claim claim){
            Type = claim.Type;
            Properties = claim.Properties;
            OriginalIssuer = claim.OriginalIssuer;
            ValueType = claim.ValueType;
            Value = claim.Value;
        }
        public string Type { get; }
        public IDictionary<string, string> Properties { get; }
        public string OriginalIssuer { get; }
        public string Issuer { get; }
        public string ValueType { get; }
        public string Value { get; }
    }
}
