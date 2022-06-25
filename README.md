# Contracts

# Mobile > Server

## APIs
1. Add points to the wallet
```
POST wallet/mint
{
	address: "0x1234", // รหัสกระเป๋า
	points: int // จำนวนแต้มที่ได้
}
```

2. Buy a product
```
POST shopping/buy
{
	address: "0x1234", // รหัสกระเป๋า
	productId: "prod1" // รหัสสินค้าที่ซื้อ
}
```

# Server > Blockchain

## Smart contract
T3Point's contracts
```csharp
interface IT3Point
{
	event Buy(productId: string, buyer: Address, receiver: Address, amount: uint246)

	Buy(productId: string, receiver: Address, amount: uint256)
}
```


# Truffle
1.Initialize
```
truffle compile
truffle console
truffle migrate

var p = await T3Point.deployed()
var add = p.address
var acc = await web3.eth.getAccounts()
```

2.Check accounts & Buy
```
(await p.balanceOf(acc[0])).toString()
(await p.balanceOf(acc[1])).toString()
(await p.balanceOf(acc[2])).toString()

await p.buy("P01", acc[1], 100)
await p.buy("P02", acc[2], 3, { from: acc[1] })

(await p.balanceOf(acc[0])).toString()
(await p.balanceOf(acc[1])).toString()
(await p.balanceOf(acc[2])).toString()
```