public interface IPort {
    void SendMIDI(byte[] midiCode);
    bool IsCodeNoteOn(byte[] midiCode);
    void SendNoteOff(byte[] midiCode);
    void closePort();
}