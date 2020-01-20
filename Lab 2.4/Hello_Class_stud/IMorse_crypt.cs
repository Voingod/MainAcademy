namespace Hello_Class_stud
{
    //Define interface IMorse_crypt wicth two methods  
    //crypt - to crypt the string
    //decrypt - to decrypt array of strings
    interface IMorse
    {
        string crypt(string word);
        string decrypt(string [] signal);
    }

}
