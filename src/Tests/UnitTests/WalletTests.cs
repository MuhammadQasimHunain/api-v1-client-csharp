﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.Blockchain.API.BlockExplorer;
using Info.Blockchain.API.Wallet;
using Xunit;

namespace Info.Blockchain.API.Tests.UnitTests
{
	public class WalletTests
	{

		private WalletHelper GetWalletHelper(BlockchainApiHelper apiHelper)
		{
			return apiHelper.CreateWalletHelper("Test", "Test");
		}

		[Fact]
		public async void ArchiveAddress_NullAddress_ArgumentNullException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.ArchiveAddress(null);
				}
			});
		}

		[Fact]
		public async void Consolidate_NegativeDays_ArgumentOutOfRangeException()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.Consolidate(-1);
				}
			});
		}

		[Fact]
		public async void GetAddress_BadParameters_ArgumentExceptions()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.GetAddressAsync(null);
				}
			});

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.GetAddressAsync("Test", -1);
				}
			});
		}

		[Fact]
		public async void ListAddresses_NegativeConfirmations_ArgumentOutOfRangeException()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.ListAddressesAsync(-1);
				}
			});
		}

		[Fact]
		public async void Send_BadParameters_ArgumentExceptions()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.SendAsync(null, BitcoinValue.Zero);
				}
			});

			await Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.SendAsync("Test", BitcoinValue.FromBtc(-1));
				}
			});
		}

		[Fact]
		public async void SendMany_NullReeipients_ArgumentNUllException()
		{
			await Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.SendManyAsync(null);
				}
			});
			await Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.SendManyAsync(new Dictionary<string, BitcoinValue>());
				}
			});
		}

		[Fact]
		public async void Unarchive_NullAddress_ArgumentNulException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(async () =>
			{
				using (BlockchainApiHelper apiHelper = UnitTestUtil.GetFakeHelper())
				{
					WalletHelper walletHelper = this.GetWalletHelper(apiHelper);
					await walletHelper.UnarchiveAddress(null);
				}
			});
		}


	}
}
