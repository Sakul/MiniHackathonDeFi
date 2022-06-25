// contracts/GLDToken.sol
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

import "./T3Point.sol";
import "@openzeppelin/contracts/token/ERC20/ERC20.sol";
import "@openzeppelin/contracts/access/Ownable.sol";

contract T3Point is ERC20, Ownable {
    
    event Buy(string productId, address buyer, address receiver, uint256 amount);

    constructor(uint256 initialSupply) ERC20("Team3Point", "T3P") {
        _mint(msg.sender, initialSupply);
    }

    function buy(string memory productId, address receiver, uint256 amount) public returns (bool) {
        address buyer = _msgSender();
        if(balanceOf(buyer) < amount) {
            return false;
        }
        
        _transfer(buyer, receiver, amount);
        emit Buy(productId, buyer, receiver, amount);
        return true;
    }

    function mint(address to, uint256 amount) public onlyOwner {
        _mint(to, amount);
    }
}
