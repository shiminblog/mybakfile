#include <iostream>
using namespace std;


class Base
{
public:
	void show() {cout <<"Hello world in Base!" << endl;}
	virtual void print(){cout <<"Print Hello world in Base !" << endl;}
};

class Child : public Base
{
public:
	void show() {cout <<"Hello world in Child!" << endl;}
	virtual void print(){cout <<"Print Hello world in Child ! " << endl;}
};


int main(void)
{
	Child c;
	Base *b = &c;

	b->show();
	b->print();

	return 0;
}
