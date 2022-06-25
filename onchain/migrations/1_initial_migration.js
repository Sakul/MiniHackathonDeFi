const Migrations = artifacts.require("Migrations");
const T3Point = artifacts.require("T3Point");

module.exports = function (deployer) {
  deployer.deploy(Migrations);
  deployer.deploy(T3Point, 100000000);
};
