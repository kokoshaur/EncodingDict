using Laba1.view_model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laba1.view
{
    class BitsFileShower
    {
        public string pathToFile;
        public string pathToOut;

        private BinaryReader file;
        private BinaryWriter cryptoFile;
        public BitsFileShower(string pathToFile, string pathToOut)
        {
            this.pathToFile = pathToFile;
            this.pathToOut = pathToOut;
            file = new BinaryReader(File.Open(pathToFile, FileMode.Open));
            cryptoFile = new BinaryWriter(File.Open(pathToOut, FileMode.OpenOrCreate));
            cryptoFile.Write(file.ReadBytes((int)Transmitter.type));
        }

        public byte[] getNextBlock()    //Возвращает следующий блок соответствующего размера из файла
        {
            if (file == null)
            {
                try
                {
                    file = new BinaryReader(File.Open(pathToFile, FileMode.Open));
                    cryptoFile = new BinaryWriter(File.Open(pathToOut, FileMode.Create));
                    cryptoFile.Write(file.ReadBytes((int)Transmitter.type));
                }
                catch (Exception e)
                {
                    Transmitter.problem(e.ToString());
                    throw;
                }
            }
            byte[] ansver = new byte[Transmitter.blockSize];

            for (int i = 0; i < Transmitter.blockSize; i++)
            {
                try
                {
                    ansver[i] = file.ReadByte();
                }
                catch (Exception e)
                {
                    byte[] tryAnsver = new byte[i];
                    Array.Copy(ansver, tryAnsver, i);
                    Transmitter.itIsLastBlock(tryAnsver);
                    return null;
                }
            }

            return ansver;
        }

        public void writeBlock(byte[] block)    //Записывает блок соответствующего размера в файл
        {
            if (cryptoFile == null)
            {
                try
                {
                    cryptoFile = new BinaryWriter(File.Open(pathToOut, FileMode.Create));
                    cryptoFile.Write(file.ReadBytes((int)Transmitter.type));
                }
                catch (Exception e)
                {
                    Transmitter.problem(e.ToString());
                    throw;
                }
            }
            cryptoFile.Write(block);
        }

        public void finish()    //Обнуляет итераторы при смене режима
        {
            if(file != null)
            {
                file.Close();
                file = null;
            }

            if(cryptoFile != null)
            {
                cryptoFile.Close();
                cryptoFile = null;
            }
        }
    }
}
