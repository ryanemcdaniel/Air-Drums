using System;

public interface ITeVirtualMIDI {
    UInt32 logWithMask(UInt32 loggingMask);
    void shutdown();
    void sendCommand( byte[] command );
    byte[] getCommand();
    UInt64[] getProcessIds();
}