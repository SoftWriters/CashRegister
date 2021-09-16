public class Denomination {

    String title;
    double value;
    // Denomination Constructor
    public Denomination(String title, double value){
        this.title = title;
        this.value = value;
    }

    public String getTitle(){
        return this.title;
    }

    public double getValue(){
        return this.value;
    }

}
