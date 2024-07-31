class Program{
    static void Main(string[] args){
        Console.Write("Ingrese sus apellidos: ");
        string apellido = Console.ReadLine().ToUpper();
        Console.Write("Ingrese sus nombres: ");
        string nombre = Console.ReadLine().ToUpper();
        Console.Write("Ingrese su año de nacimiento (Ingrese todos los dígitos 'aaaa'): ");
        int años = int.Parse(Console.ReadLine());
        Console.Write("Ingrese su mes de nacimiento (Ingrese todos los dígitos 'mm'): ");
        int mes = int.Parse(Console.ReadLine());
        Console.Write("Ingrese su dia de nacimiento (Ingrese todos los dígitos 'dd'): ");
        int dia = int.Parse(Console.ReadLine()); 
        Console.WriteLine("Su RFC es: "+Rfc(apellido, nombre, dia, mes, años));
    }
    static string Rfc(string apellido, string nombre, int dia, int mes, int años){
                //PRIMERA PARTE
        List<string> Vocales = new List<string>(){
            "A",
            "E",
            "I",
            "O",
            "U",
        };
        string letra1 = Char.ToString(apellido[0]);
        string letra2 = "";
        for(int i=0; i<(apellido.Split(' ')[0]).Count(); i++){   
            string var1 = Char.ToString(apellido[i]);
            for(int j=0; j<5; j++){
                if(var1 == Vocales[j]){
                    letra2 = Vocales[j];
                    i=apellido.Split(' ')[0].Count();
                    j=5;
                }
            }
        }
        string letra3 = Char.ToString((apellido.Split(' ')[1])[0]);
        string letra4 = Char.ToString((nombre.Split(' ')[0])[0]);
        string primeraParte = letra1+letra2+letra3+letra4;

                //SEGUNDA PARTE
        string year = " ";
        string month = " ";
        string day = " ";
        //Caso especial para los nacidos en el año 2000
        if(años%100==0){
            year = "00";
        }
        else{
            year = (años%100).ToString();
        }
        //Validaciones de las fechas (perdón profe no se me ocurrió una mejor forma sin que me diera error)
        if(mes%100<10){
            month = "0"+mes.ToString();
        }
        else{
            month = (mes%100).ToString();
        }
        if(dia%100<10){
            day = "0"+dia.ToString();
        }
        else{
            day = (dia%100).ToString();
        }
        string segundaParte = (year+month+day).ToString();

        string apellido1 = apellido.Split(' ')[0];
        
        string homoclave = "";
        Random aletorio = new Random();
        for(int j=0; j<3; j++){
            int cant;
            cant = aletorio.Next(1,3);
            if (cant==1){
                char letra = (char)aletorio.Next('A','Z'+1);
                homoclave = homoclave+letra.ToString();
            }
            else{
                homoclave = homoclave+aletorio.Next(1,10).ToString();
            }
        }
        return primeraParte+segundaParte+homoclave;
    }
}
