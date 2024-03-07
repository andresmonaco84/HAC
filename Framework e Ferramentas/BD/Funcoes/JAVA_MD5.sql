CREATE OR REPLACE AND RESOLVE JAVA SOURCE NAMED "MD5Encoder"
AS import java.security.*;
import java.lan.*;

public class MD5Encoder {

   private static String toHex(byte[] digest) {
      String buf = "";
      for (int i = 0; i < digest.length; i++) {
      String token="";
      token = Integer.toHexString(digest[i]);
      if (token.length() == 1)
      token = "0"+token;
      token= token.substring(token.length()-2);
      buf= buf+token;
   }
return buf;

}

public static String encode(String in) {
try {
String out = "";
MessageDigest md = MessageDigest.getInstance("MD5");

byte[] rawPass = in.getBytes();
try {
md.update(rawPass);
} catch (Exception e) {}
out = toHex(md.digest());
return out;
} catch (NoSuchAlgorithmException nsae) {return "";}

}
};
/ 