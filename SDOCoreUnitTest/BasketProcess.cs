using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using SDOBusinessCore.BasketProcess;
using SDOBusinessCore.Entities;
using System.Collections.Generic;
using System;
using SDOBusinessCore.Entities.Common;

namespace SDOBusinessCoreUnitTest
{
    [TestClass]
    public class BasketProcessTest
    {
        [TestMethod]
        public void AddProduct_OneProductToNewBasket_Without_Rules()
        {
            //Define the manager
            BasketManager bskProc = new BasketManager();
            
            //Configure test
            Product productOne = new Product();
            List<Product> prdList = new List<Product>();
            prdList.Add(productOne);

            //Process action
            var actual = bskProc.AddProduct(prdList,new Basket());

            //Test result
            var expected = new CommonResult() { Message = "OK", ResultStatus = CommonResult.ResultStatusAction.Success };
            actual.ResultStatus.Should().Equals(expected);
        }

        [TestMethod]
        public void AddProduct_With_BasketRuleNotNullOrEmpty_No_Product()
        {
            //Define the manager
            BasketManager bskProc = new BasketManager();

            //Configure test
            Basket basket = new Basket();            
            List<Product> prdList = new List<Product>();
            List<BasketRuleBase> listRules = new List<BasketRuleBase>();
            BasketRuleNotNullOrEmpty ruleOne = new BasketRuleNotNullOrEmpty(prdList,basket);
            listRules.Add(ruleOne);


            //Process action
            var actual = bskProc.AddProduct(prdList, basket, listRules);

            //Test result                
            var expected = new CommonResult() { Message = "KO", ResultStatus = CommonResult.ResultStatusAction.Failure };
            actual.ResultStatus.Should().Equals(expected);
        }

        [TestMethod]
        public void AddProduct_With_BasketRuleNotNullOrEmpty_No_Basket()
        {
            //Define the manager
            BasketManager bskProc = new BasketManager();

            //Configure test
            Basket basket = null;

            List<Product> prdList = new List<Product>();
            Product productOne = new Product();            
            prdList.Add(productOne);

            List<BasketRuleBase> listRules = new List<BasketRuleBase>();
            BasketRuleNotNullOrEmpty ruleOne = new BasketRuleNotNullOrEmpty(prdList, basket);
            listRules.Add(ruleOne);


            //Process action
            var actual = bskProc.AddProduct(prdList, basket, listRules);

            //Test result            
            var expected = new CommonResult() { Message = "KO", ResultStatus = CommonResult.ResultStatusAction.Failure };
            actual.ResultStatus.Should().Equals(expected);
        }

        [TestMethod]
        public void AddProduct_With_BasketRuleNotNullOrEmpty()
        {
            //Define the manager
            BasketManager bskProc = new BasketManager();

            //Configure test
            Basket basket = new Basket();

            List<Product> prdList = new List<Product>();
            Product productOne = new Product();
            prdList.Add(productOne);

            List<BasketRuleBase> listRules = new List<BasketRuleBase>();
            BasketRuleNotNullOrEmpty ruleOne = new BasketRuleNotNullOrEmpty(prdList, basket);
            listRules.Add(ruleOne);


            //Process action
            var actual = bskProc.AddProduct(prdList, basket, listRules);

            //Test result            
            var expected = new CommonResult() { Message = "OK", ResultStatus = CommonResult.ResultStatusAction.Success };
            actual.ResultStatus.Should().Equals(expected);
        }

        [TestMethod]
        public void CleanBasket_With_Products()
        {
            //Define the manager
            BasketManager bskProc = new BasketManager();

            //Configure test
            Basket basket = new Basket();

            List<Product> prdList = new List<Product>();
            Product productOne = new Product();
            Product productTwo = new Product();
            prdList.Add(productOne);
            prdList.Add(productTwo);
            bskProc.AddProduct(prdList, basket);

            //Process action
            var actual = bskProc.CleanBasket(basket);

            //Test
            var expected  = new CommonResult() { Message = "OK", ResultStatus = CommonResult.ResultStatusAction.Success };
            actual.ResultStatus.Should().Equals(expected);
            
        }

        [TestMethod]
        public void CleanBasket_With_ProductsNull()
        {
            //Define the manager
            BasketManager bskProc = new BasketManager();

            //Configure test
            Basket basket = new Basket();
            basket.Products = null;

            //Process action
            var act = bskProc.CleanBasket(basket);
            act.Should().Match<CommonResult>(d => d.ResultStatus == CommonResult.ResultStatusAction.Failure);
        }
    }
}
