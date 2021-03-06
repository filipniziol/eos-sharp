﻿using EosSharp.Api.v1;
using EosSharp.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EosSharp.UnitTests
{
    [TestClass]
    public class EosUnitTests
    {
        Eos Eos { get; set; }
        public EosUnitTests()
        {
            Eos = new Eos(new EosConfigurator()
            {
                SignProvider = new DefaultSignProvider("5K57oSZLpfzePvQNpsLS6NfKXLhhRARNU13q6u2ZPQCGHgKLbTA"),

                //HttpEndpoint = "https://nodes.eos42.io", //Mainnet
                //ChainId = "aca376f206b8fc25a6ed44dbdc66547c36c6c33e3a119ffbeaef943642f0e906"

                HttpEndpoint = "https://nodeos01.btuga.io",
                ChainId = "cf057bbfb72640471fd910bcb67639c22df9f92470936cddc1ade0e2f2e7dc4f"
            });
        }

        [TestMethod]
        public async Task CreateTransaction()
        {
            bool success = false;
            try
            {
                var result = await Eos.CreateTransaction(new Transaction()
                {
                    Actions = new List<Api.v1.Action>()
                    {
                        new Api.v1.Action()
                        {
                            Account = "eosio.token",
                            Authorization = new List<PermissionLevel>()
                            {
                                new PermissionLevel() {Actor = "tester112345", Permission = "active" }
                            },
                            Name = "transfer",
                            Data = new { from = "tester112345", to = "tester212345", quantity = "0.0001 EOS", memo = "hello crypto world!" }
                        }
                    }
                });
                success = true;
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode);
                Console.WriteLine(ex.Content);
            }

            Assert.IsTrue(success);
        }
    }
}
