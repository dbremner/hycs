delegate void Profession();

class ProfessionSpeaker{

    static void StaticSpeaker(){
        System.Console.WriteLine("Medicine");
    }

    static int doctorIdCounter = 0;
    int doctorId = doctorIdCounter++;

    void InstanceSpeaker(){
        System.Console.WriteLine("Doctor " + doctorId);
    }
    int DifferentSignature(){
        System.Console.WriteLine("Firefighter");
        return 0;
    }

    public static void Main(){
        //declare delegate reference (== null)
        Profession p;
        //instantiate delegate reference
        p = new Profession(ProfessionSpeaker.StaticSpeaker);
        p();

        ProfessionSpeaker s1 = new ProfessionSpeaker();
        ProfessionSpeaker s2 = new ProfessionSpeaker();

        //"instantiate" to specific instances
        Profession p1 = new Profession(s1.InstanceSpeaker);
        Profession p2 = new Profession(s2.InstanceSpeaker);


        p1();
        p2();

        //Won't compile, different signature
        //Profession p3 = new Profession(
        //   s2.DifferentSignature);
        System.Console.ReadKey();
    }
}

