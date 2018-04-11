using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking
{
    class ErrorEntity
    {
        private string errorEmpty;
        private string errorLength;
        private string errorCharacter;

        public ErrorEntity()
        {
        }

        public ErrorEntity(string errorEmpty, string errorLength, string errorCharacter)
        {
            this.errorEmpty = errorEmpty;
            this.errorLength = errorLength;
            this.errorCharacter = errorCharacter;
        }

        public string ErrorEmpty { get => errorEmpty; set => errorEmpty = value; }
        public string ErrorLength { get => errorLength; set => errorLength = value; }
        public string ErrorCharacter { get => errorCharacter; set => errorCharacter = value; }
    }
}
