# Transcoding0804
AESController 統一發票加密

release to  https://azurewebsites.net

https://ciper804.azurewebsites.net/Ciphert/PL49821416/5871/F1A618ED8685B1A3B81E6CB6884617F4


in localhost 
https://localhost:44320/Ciphert/

PL49821416/5871/F1A618ED8685B1A3B81E6CB6884617F4


InvoiceNumber = PL49821416

RandomNumber = 5871

AESKey = F1A618ED8685B1A3B81E6CB6884617F4


     [HttpGet("{IN}/{RN}/{Key}")]
     public string Get(string IN, string RN, string Key)
        {
            QREncrypter.InvoiceNumber = IN;
            QREncrypter.RandomNumber = RN;
            QREncrypter.AESKey = Key;
            return QREncrypter.CiphertGet();
        }
        
The return  QREncrypter.CiphertGet()

E95eNqkzodO49TnX0I8vcg==
