using IdentityServer4.Models;

namespace AuthServer
{
    static public class Config
    {
        #region Api Scopes
        // Permissions that can be used in Resource Apis are defined.
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("Bitcoin.Write","Bitcoin hesabında transfer izni"),
                new ApiScope("Bitcoin.Read","Bitcoin hesabında okuma izni"),
                new ApiScope("Bitcoin.Admin","Bitcoin hesabında tam izin"),

                new ApiScope("Ethereum.Write","Ethereum  hesabında transfer izni"),
                new ApiScope("Ethereum.Read","Ethereum hesabında okuma izni"),
                new ApiScope("Ethereum.Admin","Ethereum hesabında tam izin"),

            };
        }
        #endregion
        #region Resources
        // Resource API definitions are made.
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Bitcoin"){ // This represents the username of the Resource Api
                    ApiSecrets={new Secret("btc".Sha256())}, // This represents the password of the Resource Api
                    Scopes={"Bitcoin.Read","Bitcoin.Write","Bitcoin.Admin"}
                },
                new ApiResource("Ethereum"){ // This represonts the username of the Resource Api
                    ApiSecrets={new Secret("eth".Sha256())}, // This represents the password of the Resource Api
                    Scopes={ "Ethereum.Read", "Ethereum.Write","Ethereum.Admin"}
                },
            };
        }
        #endregion
        #region Clients
        // Client definitions are made for clients that will use Resource APIs.
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="BTC",
                    ClientName="Bitcoin",
                    ClientSecrets={new Secret("btc".Sha256())},
                    AllowedGrantTypes={GrantType.ClientCredentials},
                    AllowedScopes={"Bitcoin.Read","Bitcoin.Admin"},
                },
                new Client
                {
                    ClientId="ETH",
                    ClientName="Ethereum",
                    ClientSecrets={new Secret("eth".Sha256())},
                    AllowedGrantTypes={GrantType.ClientCredentials},
                    AllowedScopes={"Ethereum.Read","Ethereum.Write"},
                }
            };
        }
        #endregion
    }
}
