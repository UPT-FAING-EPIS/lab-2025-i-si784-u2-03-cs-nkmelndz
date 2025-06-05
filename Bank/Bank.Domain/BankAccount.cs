using System;

namespace Bank.Domain
{
    /// <summary>
    /// Representa una cuenta bancaria con operaciones básicas de débito y crédito.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Mensaje de error cuando el monto del débito excede el saldo disponible.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Mensaje de error cuando el monto del débito es menor que cero.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Constructor privado para evitar instancias sin información inicial.
        /// </summary>
        private BankAccount() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="BankAccount"/> con nombre de cliente y saldo inicial.
        /// </summary>
        /// <param name="customerName">Nombre del titular de la cuenta.</param>
        /// <param name="balance">Saldo inicial de la cuenta.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Obtiene el nombre del cliente asociado a la cuenta.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Obtiene el saldo actual de la cuenta.
        /// </summary>
        public double Balance { get { return m_balance; } }

        /// <summary>
        /// Realiza una operación de débito en la cuenta.
        /// </summary>
        /// <param name="amount">Cantidad a debitar.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza si <paramref name="amount"/> es negativo o mayor que el saldo actual.
        /// </exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            m_balance -= amount; 
        }

        /// <summary>
        /// Realiza una operación de crédito en la cuenta.
        /// </summary>
        /// <param name="amount">Cantidad a acreditar.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza si <paramref name="amount"/> es negativo.
        /// </exception>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance += amount;
        }
    }
}
