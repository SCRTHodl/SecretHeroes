
const TestnetConf: NetworkConfig = {
  chainId: 'holodeck-2',
  chainName: 'Secret Testnet',
  rpc: 'http://bootstrap.secrettestnet.io:26657',
  rest: 'https://bootstrap.secrettestnet.io',
  bip44: {
    coinType: 529
  },
  coinType: 529,
  stakeCurrency: {
    coinDenom: 'SCRT',
    coinMinimalDenom: 'uscrt',
    coinDecimals: 6
  },
  bech32Config: {
    bech32PrefixAccAddr: 'secret',
    bech32PrefixAccPub: 'secretpub',
    bech32PrefixValAddr: 'secretvaloper',
    bech32PrefixValPub: 'secretvaloperpub',
    bech32PrefixConsAddr: 'secretvalcons',
    bech32PrefixConsPub: 'secretvalconspub'
  },
  currencies: [
    {
      coinDenom: 'SCRT',
      coinMinimalDenom: 'uscrt',
      coinDecimals: 6
    }
  ],
  feeCurrencies: [
    {
      coinDenom: 'SCRT',
      coinMinimalDenom: 'uscrt',
      coinDecimals: 6
    }
  ],
  gasPriceStep: {
    low: 0.1,
    average: 0.25,
    high: 0.4
  },
  features: ['secretwasm']
}

export {TestnetConf}
