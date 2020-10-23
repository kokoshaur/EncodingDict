using System;
using System.Collections.Generic;
using System.Text;
using Laba1.view_model;

namespace Laba1.model.Subj
{
    class SAFERCrypto : ICrypto
    {
        public bool isCrypto = false;

        private byte[] subjKey;
        private byte[] key;
        private byte[] IV;
        private byte[] NextIV;

        public SAFERCrypto(byte[] key, byte[] IV)
        {
            subjKey = key;
            this.key = key;
            this.IV = IV;
            NextIV = IV;
        }
        public void init()              //Инициализирует переменную размера блока, приравнивая её к весу ключа
        {
            Transmitter.blockSize = key.Length;
        }
        public void encryptFile(byte pos = 0)       //Шифрует файл
        {
            key = (byte[])subjKey.Clone();
            NextIV = (byte[])IV.Clone();
            isCrypto = true;
            byte[] block;

            while ((block = Transmitter.getNextBlock()) != null)
            {
                cryptoBlock(block, pos);
            }

            Transmitter.BitsFinish();
        }
        public void decryptoFile()  //Дешифрует файл
        {
            key = (byte[])subjKey.Clone();
            NextIV = (byte[])IV.Clone();
            isCrypto = false;
            byte[] block;

            while ((block = Transmitter.getNextBlock()) != null)
            {
                decryptoBlock(block);
            }

            Transmitter.BitsFinish();
        }
        public void itIsLast(byte[] block)  //Вызывается на завершающем блоке, т.к. он чаще всего обрывается (меньше заданного размера)
        {
            if (isCrypto)
                cryptoBlock(block);
            else
                decryptoBlock(block);
        }

        private void cryptoBlock(byte[] block, byte pos = 0)  //Шифрует 1 блок
        {
            CFB(ref block, pos);
            NextIV = (byte[])block.Clone();

            for (int i = 0; i < (block.Length/16); i++)
            {
                forceKey(ref block);

                for (int j = 0; j < key.Length; j++)
                    key[j] = (byte)(key[j] + (3 * i));
            }

            Transmitter.writeBlock(block);
        }

        private void decryptoBlock(byte[] block)    //Расшифровыывает 1 блок
        {
            for (int i = 0; i < (block.Length/16); i++)
            {
                forceKey(ref block);

                for (int j = 0; j < key.Length; j++)
                    key[j] = (byte)(key[j] + (3 * i));
                
            }

            byte[] buf = (byte[])block.Clone();
            CFB(ref block);
            NextIV = (byte[])buf.Clone();

            Transmitter.writeBlock(block);
        }

        private void CFB(ref byte[] block, byte mis = 0)  //СФБ
        {
            if (isCrypto)
                for (int i = 0; i < block.Length; i++)
                    if ((mis != 0) && (mis == i))
                        block[i] += (byte) (NextIV[i] + mis);
                    else
                        block[i] += NextIV[i];

            else
                for (int i = 0; i < block.Length; i++)
                    block[i] -= NextIV[i];
        }

        private void forceKey(ref byte[] block) //Применяет ключ к блоку (1 итерация)
        {
            if (isCrypto)
                for (int i = 0; i < block.Length; i++)
                    if (i % 2 == 0)
                        block[i] ^= key[i];
                    else
                        block[i] += key[i];
            else
                for (int i = 0; i < block.Length; i++)
                    if (i % 2 == 0)
                        block[i] = (byte)(key[i] ^ block[i]);
                    else
                        block[i] -= key[i];
        }
    }
}
