using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InternetBanking
{
    class History
    {
        private string tradingCode;
        private string sendBankId;
        private string receiveBankId;
        private double amount;
        private string content;
        private long dateTransaction;
        private string status;
       
        public History()
        {

        }

       

        public History(string tradingCode, string sendBankId, string receiveBankId, double amount, string content)
        {
            this.TradingCode = tradingCode;
            this.SendBankId = sendBankId;
            this.ReceiveBankId = receiveBankId;
            this.Amount = amount;
            this.Content = content;
            LongTime longtime = new LongTime();
            this.DateTransaction = longtime.CurrentTimeMillis();
        }

        public History(string tradingCode, string sendBankId, string receiveBankId, double amount, string content, long dateTransaction)
        {
            this.tradingCode = tradingCode;
            this.sendBankId = sendBankId;
            this.receiveBankId = receiveBankId;
            this.amount = amount;
            this.content = content;
            this.dateTransaction = dateTransaction;
        }

        public string TradingCode { get => tradingCode; set => tradingCode = value; }
        public string SendBankId { get => sendBankId; set => sendBankId = value; }
        public string ReceiveBankId { get => receiveBankId; set => receiveBankId = value; }
        public double Amount { get => amount; set => amount = value; }
        public string Content { get => content; set => content = value; }
        public long DateTransaction { get => dateTransaction; set => dateTransaction = value; }
        public string Status { get => status; set => status = value; }
    }
}
