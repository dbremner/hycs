using System;
using System.Threading;

class HelloThread {
    static void Main() {
        int n = 100;
        Thread t = new Thread (WriteY);
        t.Start();
        while (0 != n) {
            Console.Write("x");
            n--;
        }
    }

    static void WriteY() {
        int n = 100;
        while (0 != n) {
            Console.Write("y");
            n--;
        }
    }
}
