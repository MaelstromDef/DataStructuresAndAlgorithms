#include "Heap.h"
#include <iostream>
#include <stdexcept>

/// <summary>
/// Initializes a heap array with a given max size.
/// </summary>
/// <param name="size">Size of the array to be allocated.</param>
MinHeap::MinHeap(int size) {
	maxSize = size;
	heap = new int[maxSize];
}

/// <summary>
/// Frees memory for all pointers within heap and then heap itself.
/// </summary>
MinHeap::~MinHeap() {
	delete(heap);
}

/// <summary>
/// Prints the heap.
/// </summary>
void MinHeap::Print() {
	int rowSize = 1;

	for (int i = 0; i < currentSize; i++) {
		std::cout << heap[i] << ", ";
	}
}

/// <summary>
/// Turns the stored array into a heap.
/// </summary>
void MinHeap::Heapify(int i) {
	if (i < 0 || i >= currentSize) throw std::range_error("Index given to Heapify is out of bounds.");

	// INSERTION ONLY
	int current = heap[i];
	if (i != 0) {
		int p = heap[parent(i)];

		if (current < p) {
			int temp = p;
			heap[parent(i)] = current;
			heap[i] = temp;
			Heapify(parent(i));
		}
	}

	// DELETION ONLY
	int lIndex = lChild(i);
	int rIndex = rChild(i);
	int smallest = i;
	
	if (lIndex < currentSize && heap[lIndex] < heap[smallest])
		smallest = lIndex;
	if (rIndex < currentSize && heap[rIndex] < heap[smallest])
		smallest = rIndex;
	if (smallest != i) {
		int temp = heap[smallest];
		heap[smallest] = heap[i];
		heap[i] = temp;
		Heapify(smallest);
	}
}

/// <summary>
/// Inserts a number into the heap, ensuring heap maintains heap properties.
/// </summary>
/// <param name="number">Number to insert.</param>
void MinHeap::Insert(int number) {
	if (currentSize >= maxSize) return;
	heap[currentSize++] = number;
	Heapify(currentSize - 1);
}

/// <summary>
/// Removes the top value from the heap and ensures heap properties are maintained.
/// </summary>
/// <returns>Previous top value.</returns>
int MinHeap::Delete() {
	int min = GetMin();

	currentSize--;
	if (currentSize < 0) currentSize = 0;
	heap[0] = heap[currentSize];

	Heapify(0);

	return min;
}

/// <summary>
/// Gets the min value of the heap.
/// </summary>
/// <returns>Heap's min value.</returns>
int MinHeap::GetMin() {
	if (currentSize == 0) throw std::out_of_range("Heap is empty");
	return heap[0];
}

int MinHeap::parent(int i) {
	return (i - 1) / 2;
}

int MinHeap::lChild(int i) {
	return 2 * i + 1;
}

int MinHeap::rChild(int i) {
	return 2 * i + 2;
}