// Задача 6: Система "Платежи"

using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNET_module_4_practice
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public bool IsBlocked { get; set; }

        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0.0;
            IsBlocked = false;
        }
    }

    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }
        public double CreditLimit { get; set; }
        public bool IsBlocked { get; set; }

        public CreditCard(string cardNumber, string accountNumber, double creditLimit)
        {
            CardNumber = cardNumber;
            AccountNumber = accountNumber;
            CreditLimit = creditLimit;
            IsBlocked = false;
        }
    }

    public class PaymentSystem
    {
        private List<BankAccount> bankAccounts = new List<BankAccount>();
        private List<CreditCard> creditCards = new List<CreditCard>();

        public void AddBankAccount(BankAccount bankAccount)
        {
            bankAccounts.Add(bankAccount);
        }

        public void AddCreditCard(CreditCard creditCard)
        {
            creditCards.Add(creditCard);
        }

        public void MakePayment(string sourceAccountNumber, string destinationAccountNumber, double amount)
        {
            var sourceAccount = bankAccounts.FirstOrDefault(account => account.AccountNumber == sourceAccountNumber);
            var destinationAccount = bankAccounts.FirstOrDefault(account => account.AccountNumber == destinationAccountNumber);

            if (sourceAccount != null && destinationAccount != null && !sourceAccount.IsBlocked)
            {
                if (sourceAccount.Balance >= amount)
                {
                    sourceAccount.Balance -= amount;
                    destinationAccount.Balance += amount;
                }
                else if (sourceAccount.Balance + GetCreditLimit(sourceAccount.AccountNumber) >= amount)
                {
                    sourceAccount.Balance -= amount;
                    destinationAccount.Balance += amount;
                }
                else
                {
                    Console.WriteLine("Недостаточно средств для выполнения платежа.");
                }
            }
            else
            {
                Console.WriteLine("Один из аккаунтов заблокирован или не существует.");
            }
        }

        public void BlockCreditCard(string cardNumber)
        {
            var creditCard = creditCards.FirstOrDefault(card => card.CardNumber == cardNumber);
            if (creditCard != null)
            {
                creditCard.IsBlocked = true;
            }
        }

        public double GetCreditLimit(string accountNumber)
        {
            var creditCard = creditCards.FirstOrDefault(card => card.AccountNumber == accountNumber);
            return creditCard != null ? creditCard.CreditLimit : 0.0;
        }
    }
}