using System;
using TobiasErichsen.teVirtualMIDI;

public class Port : IPort {
    private static ITeVirtualMIDI port;
    private static byte[] c_midC_on = { 0b10011010, 97, 0b01111111 };
    private static byte[] c_midC_off = { 0b10001010, 97, 0b01111111 };

    private static byte[] c_92_on = { 0b10011010, 92, 0b01111111 };
    private static byte[] c_92_off = { 0b10001010, 92, 0b01111111 };

    private static byte[] c_play = { 0b11111010, 0 ,0 };
    private static byte[] c_pause = { 0b11111100, 0, 0 };

    private static Guid manufacturer = new Guid("aa4e075f-3504-4aab-9b06-9a4104a91cf0");
    private static Guid product = new Guid("bb4e075f-3504-4aab-9b06-9a4104a91cf0");

    public Port() {
        TeVirtualMIDI.logging(TeVirtualMIDI.TE_VM_LOGGING_MISC | TeVirtualMIDI.TE_VM_LOGGING_RX | TeVirtualMIDI.TE_VM_LOGGING_TX);
        port = new TeVirtualMIDI("C# loopback", 65535, TeVirtualMIDI.TE_VM_FLAGS_PARSE_RX, ref manufacturer, ref product);
    }

    private void sendMIDI(byte[] midiCode) {
        port.sendCommand(midiCode);
        
    }
    
    public void playNote() {
        sendMIDI(c_midC_on);
        System.Threading.Thread.Sleep(100);
        sendMIDI(c_midC_off);
    }

    public void playNote2() {
        sendMIDI(c_92_on);
        System.Threading.Thread.Sleep(100);
        sendMIDI(c_92_off);
    }

    public void play() {
        sendMIDI(c_play);
    }

    public void pause(){
        sendMIDI(c_pause);
    }
    public void closePort(){
        port.shutdown();
    }
}