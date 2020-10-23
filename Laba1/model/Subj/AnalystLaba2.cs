using System;
using System.Collections.Generic;
using System.Text;
using Laba1.view_model;

namespace Laba1.model.Subj
{
    class AnalystLaba2 : IAnalyst
    {
        public AnalystLaba2(ICrypto methodCrypto, fileType type, string pathToInput = null, string pathToOutput = null, string pathToSecond = null)
        {
            byte[] key = new byte[128];
            byte[] IV = new byte[128];
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = (byte)(i + 100);
                IV[i] = (byte)(i + 100);
            }

            Transmitter.init(methodCrypto, type, pathToInput, pathToOutput);

            Transmitter.startEncrypt(100);

            Transmitter.setPathToInp(pathToOutput);
            Transmitter.setPathToOut(pathToSecond);

            Transmitter.startDecrypt();
        }

        public Dictionary<Place, int> FreqAnal()
        {
            throw new NotImplementedException();
        }
    }
}
