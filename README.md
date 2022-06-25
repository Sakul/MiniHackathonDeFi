# Contracts

# Mobile > Server

## APIs
1. เพิ่มแต้มให้กระเป๋าเมื่อเดินครบเงื่อนไข
```
POST wallet/mint
{
	address: "0x1234", // รหัสกระเป๋า
	points: int // จำนวนแต้มที่ได้
}
```

2. สั่งซื้อสินค้า
```
POST shopping/buy
{
	address: "0x1234", // รหัสกระเป๋า
	productId: "prod1" // รหัสสินค้าที่ซื้อ
}
```

# Server > Blockchain

TBD