public interface IProc {

    void Pipeline();

    void Loop() {
        for (;;) {
            Pipeline();
        }
    }

}