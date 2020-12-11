public interface IProc {

    void Pipeline();

    void Run() {
        for (;;) {
            Pipeline();
        }
    }

}