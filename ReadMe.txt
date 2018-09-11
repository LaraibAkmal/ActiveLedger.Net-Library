
Add the Reference of  the ActiveLedger library in your Visual Studio project



How to use the Activeledger Functions

---------Initialise the SDK-------------------------

ActiveLedgerLib.SDKPreferences.setSettings("protocol", "URL", "port");
For Example:
ActiveLedgerLib.SDKPreferences.setSettings("http", "testnet-eu.activeledger.io", "5260");


---------Generate KeyPair-------------------------

AsymmetricCipherKeyPair keypair = ActiveLedgerLib.GenerateKeyPair.GetKeyPair(KeyType);
For Example
AsymmetricCipherKeyPair keypair = ActiveLedgerLib.GenerateKeyPair.GetKeyPair(type);


---------Writing KeyPair in the file in PEM Format-------------------------
ActiveLedgerLib.Helper.WritekeyPairInFile(PathOfFile, AsymmetricCipherKeyPair);
For Example:
ActiveLedgerLib.Helper.WritekeyPairInFile(RSAkeypairPathPEMFile, keypair);


---------Writing Only the Public Key in the file in PEM Format ------------------------
ActiveLedgerLib.Helper.WritePublicKeyInFile(PathOfFile, AsymmetricCipherKeyPair);
Example
ActiveLedgerLib.Helper.WritePublicKeyInFile(RSApublicKeyPathPEMFile, keypair);

---------Reading Only the Pem Format key pair from the user file and return the Asymmetric Keypair ------------------------
AsymmetricCipherKeyPair keypair = ActiveLedgerLib.Helper.ReadAsymmetricKeyParameter(PathOfFile);
For Example:
AsymmetricCipherKeyPair keypair = ActiveLedgerLib.Helper.ReadAsymmetricKeyParameter(RSAkeypairPathPEMFile);



---------Onboard KeyPair-------------------------

1. generate Json Object for onBoaring keys
JObject json = ActiveLedgerLib.GenerateTxJson.GetTxJsonForOnboardingKeys(PathOfPublicKeyFile, AsymmetricKeypair,TypeofKey);
For Example:
JObject json = ActiveLedgerLib.GenerateTxJson.GetTxJsonForOnboardingKeys(RSApublicKeyPathPEMFile, keypair, type);
2. Request Activeledger for onboarding keys
var response = ActiveLedgerLib.MakeRequest.makeRequestAsync(SDKPrefernece, jsonObjectIntheFormOfString);
For Example:
var response = ActiveLedgerLib.MakeRequest.makeRequestAsync(ActiveLedgerLib.SDKPreferences.getSetting(), json_str);







