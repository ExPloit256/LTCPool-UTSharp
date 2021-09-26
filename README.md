# What is LTCPool-UTSharp?
LTCPool-UTSharp is a simple utility tool made to ease litecoinpool.org user's life with LTC mining managing, this application, will display all your stats onto a quick and easy-to-access viewport.
the only thing you will need to do is a brief setup, it won't take more than 10 seconds, setting it up is as easy as drinking a glass of water. 

# How to set it up
Open the settings.json file in the same path of the application and you should see some text layed out in this format.
| Type | Value |
| --- | --- |
| apiKey | Your litecoinpool.org api key, you can get it here https://www.litecoinpool.org/account |
| currency | The currency you want to use for translating your LTC values you can choose between: LTC, BTC, USD, CAD, EUR, GBP, RUB, CNY, AUD, ZAR |
| hashScale | Your preferred scale for hashing values you can choose between: H, KH, MH, GH, TH | 

**BE SURE TO LEAYOUT EVERYTHING IN THE CORRECT FORMAT E.G:**
```
{
   "apiKey": "API KEY HERE",
   "currency": "EUR",
   "hashScale": "MH"
}
```
Once you have layed out everything correctly you are ready to start using the app. 
