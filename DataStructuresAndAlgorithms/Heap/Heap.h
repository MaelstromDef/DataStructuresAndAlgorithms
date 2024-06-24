#pragma once
class MinHeap
{
private:
	int* heap;
	int maxSize;
	int currentSize = 0;

	int parent(int i);
	int lChild(int i);
	int rChild(int i);
	void Heapify(int i);

public:
	MinHeap(int size);
	~MinHeap();

	void Print();
	void Insert(int number);
	int Delete();
	int GetMin();
};