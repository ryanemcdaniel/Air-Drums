using System;

public interface IteVirtualMIDI {
    public UInt32 logWithMask(UInt32 loggingMask);
    public void shutdown();
    public void sendCommand( byte[] command );
    public byte[] getCommand();
    public UInt64[] getProcessIds();
}