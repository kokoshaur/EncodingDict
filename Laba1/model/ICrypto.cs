namespace Laba1.model
{
    interface ICrypto
    {
        public void itIsLast(byte[] block); //Вызывается на завершающем блоке, т.к. он чаще всего обрывается (меньше заданного размера)  
        public void init();
        public void encryptFile(); //Шифрует файл
        public void decryptoFile(); //Дешифрует файл
    }
}
