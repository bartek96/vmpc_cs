using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VmpcTest
{
	public class Vmpc
	{
		/*---------------------------------------------------------------------------------------------------

		Implementation of the VMPC Stream Cipher
		and 
		the VMPC-MAC Authenticated Encryption Scheme
		in C#

		Author of the algorithms:		Bartosz Zoltak		(www.vmpcfunction.com)
		Author of the implementation:	Bartosz Wawrzyniak	(smart-room.eu)
		*/


		// VMPC engine state variables
		byte[] P = new byte[256];
		byte s, n;

		// VMPC-MAC engine state variables
		byte[] MAC = new byte[32];
		byte m1, m2, m3, m4, mn;


		// Public methods for VMPC encryption
		public void InitKeyRound(byte[] data, int len, bool firstInit)
		{
			if (firstInit) 
			{
				for(int i = 0 ; i < P.Length ; i++)
					P[i] = (byte)i;
				s=0;
			}

			n=0;
			byte k = 0;
			byte tmp;
			for (int i = 0; i < 768; i++)
			{
				s = P[ (s + P[n] + data[k]) & 0xFF ];

				tmp  = P[n];
				P[n] = P[s];  
				P[s] = tmp;

				k++;  
				if (k == len) k=0;
				n++;
			}
		}


		public void InitKey(byte[] key, int keyLen , byte[] iv, int ivLen)   //KeyLen, VecLen = 1,2,3,...,64
		{
			InitKeyRound(key, keyLen, true);
			InitKeyRound(iv , ivLen , false);
			InitKeyRound(key, keyLen, false);
		}


		public void InitKeyBASIC(byte[] key, int keyLen, byte[] iv,  int ivLen)   //KeyLen, VecLen = 1,2,3,...,64
		{
			InitKeyRound(key, keyLen, true);
			InitKeyRound(iv , ivLen , false);
		}


		public void Encrypt(byte[] data, int len)
		{
			byte tmp;
			for (int i = 0; i < len; i++)
			{
				s = P[ (s + P[n]) & 0xFF ];

				data[i] ^= P[(P[P[ s ]] + 1) & 0xFF];

				tmp  = P[n];  
				P[n] = P[s];  
				P[s] = tmp;

				n++;
			}
		}


		// Public methods for VMPC-MAC encryption
		public void InitMAC()
		{
			m1 = m2 = m3 = m4 = mn = 0;
			for(int i = 0 ; i < MAC.Length ; i++)
				MAC[0] = 0;
		}



		public void EncryptMAC(byte[] data, int len)
		{
			byte tmp;
			for (int i = 0; i < len; i++)
			{
				s=P[ (s + P[n]) & 0xFF ];

				data[i] ^= P[(P[P[ s ]]+1) & 0xFF];

				m4 = P[(m4 + m3) & 0xFF];
				m3 = P[(m3 + m2) & 0xFF];
				m2 = P[(m2 + m1) & 0xFF];
				m1 = P[(m1 + s + data[i]) & 0xFF];

				MAC[mn]		^=	m1;
				MAC[mn+1]	^=	m2;
				MAC[mn+2]	^=	m3;
				MAC[mn+3]	^=	m4;

				tmp = P[n];  
				P[n] = P[s];  
				P[s] = tmp;

				//mn = (mn + 4) & 31;
				mn += 4;
				mn &= 31;
				n++;
			}
		}



		public void DecryptMAC(byte[] data, int len)
		{
			byte tmp;
			for (int i = 0; i < len; i++)
			{
				s = P[(s + P[n]) & 0xFF];

				m4 = P[(m4 + m3) & 0xFF];
				m3 = P[(m3 + m2) & 0xFF];
				m2 = P[(m2 + m1) & 0xFF];
				m1 = P[(m1 + s + data[i]) & 0xFF];

				MAC[mn]		^=	m1;
				MAC[mn+1]	^=	m2;
				MAC[mn+2]	^=	m3;
				MAC[mn+3]	^=	m4;

				data[i] ^= P[(P[P[s]] + 1) & 0xFF];

				tmp  = P[i];  
				P[n] = P[s];  
				P[s] = tmp;

				//mn = (mn + 4) & 31;
				mn += 4;
				mn &= 31;
				n++;
			}
		}



		public void OutputMAC()
		{
			byte tmp;
			for (int i = 1; i <= 24; i++)
			{
				s = P[(s + P[n]) & 0xFF];

				m4 = P[(m4 + m3 + i) & 0xFF];
				m3 = P[(m3 + m2 + i) & 0xFF];
				m2 = P[(m2 + m1 + i) & 0xFF];
				m1 = P[(m1 + s + i) & 0xFF];

				MAC[mn]		^=	m1;
				MAC[mn+1]	^=	m2;
				MAC[mn+2]	^=	m3;
				MAC[mn+3]	^=	m4;

				tmp  = P[n];  
				P[n] = P[s];  
				P[s] = tmp;

				//mn = (mn + 4) & 31;
				mn += 4;
				mn &= 31;
				n++;
			}
			InitKeyRound(MAC, 32, false);

			for (int i = 0; i < 20; i++)
				MAC[i] = 0;
			Encrypt(MAC, 20);
		}



		public void EraseKey()
		{
			for (int i = 0; i < P.Length; i++)
				P[i] = 0;
			for (int i = 0; i < MAC.Length; i++)
				MAC[i] = 0;
			s = n = m1 = m2 = m3 = m4 = mn = 0;
		}
	}
}
