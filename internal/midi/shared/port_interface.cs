

public interface IPort {
    private void sendMIDI(byte[] midiCode);
    
    public void playNote();

    public void playNote2();

    public void play();

    public void pause();
    public void closePort();
}