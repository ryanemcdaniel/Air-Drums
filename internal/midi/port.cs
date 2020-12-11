using System;
using TobiasErichsen.teVirtualMIDI;

public class Port : IPort {
    private ITeVirtualMIDI midiDispatch;
    private static byte[] c_midC_on = { 0b10011010, 97, 0b01111111 };
    private static byte[] c_midC_off = { 0b10001010, 97, 0b01111111 };

    private static byte[] c_92_on = { 0b10011010, 92, 0b01111111 };
    private static byte[] c_92_off = { 0b10001010, 92, 0b01111111 };

    private static byte[] c_play = { 0b11111010, 0 ,0 };
    private static byte[] c_pause = { 0b11111100, 0, 0 };

    public Port(ITeVirtualMIDI tvm) {
        midiDispatch = tvm;
    }

    // TODO lift out into documentation
    // USEFUL TO KNOW FOR NOW
    // TeVirtualMIDI.logging(TeVirtualMIDI.TE_VM_LOGGING_MISC | TeVirtualMIDI.TE_VM_LOGGING_RX | TeVirtualMIDI.TE_VM_LOGGING_TX);
    //     port = new TeVirtualMIDI("C# loopback", 65535, TeVirtualMIDI.TE_VM_FLAGS_PARSE_RX, ref manufacturer, ref product);

    public void SendMIDI(byte[] midiCode) {
        midiDispatch.sendCommand(midiCode);
    }

    public bool IsCodeNoteOn(byte[] midiCode) {
        return (midiCode[0] & 0b11110000) == 0b10010000;
    }

    public void SendNoteOff(byte[] midiCode) {
        var noteOff = (byte) (midiCode[0] & 0b00001111 + 0b10000000);
        midiDispatch.sendCommand(new byte[]{noteOff, midiCode[1], midiCode[2]});
    }

    public void ClosePort(){
        midiDispatch.shutdown();
    }
}