
----- TEST INSTRUCTIONS -----
In this solution, you will find a set of Unit Tests that are all failing.
You should made the required changes to make them all pass. DO NOT MODIFY UNIT TESTS! You are only expected to code within the GunvorAssessment Project.

The business case covered by these tests is as follows:

As a client, I should be able to withdraw money from my CURRENT ACCOUNT up-to the agreed overdraft (the overdraft limit though is always expressed as a negative number)
As a client, I should be able to withdraw money from my SAVINGS ACCOUNT as long as my account balance remains > 0 (No overdraft facility is available on saving accounts)
On a saving account, I cannot withdraw more than 10% of my account's balance in a single transaction
Amount withdrawn or deposited are always positive amounts
Audit should be able to retrieve transactions for a given account. Each transaction should be uniquely identified
A transaction should record the date it happened and the Type of transaction
If multiple amounts are deposited concurrently, then the final balance should reflect the correct amount
A bank can go into Lockdown mode, which means when that happens no Deposit/Withdrawals are available