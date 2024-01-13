Feature: Ordering

@mytag
Scenario: The price of order is calculated correctly
	Given I entered the following data into the new order form:
    | customerId | address | percentageDiscount | profit |
    | 1          | adress  | 25                 | 10000  |
	Given I entered the following order items into the order form:
    | productId | unitPrice | units |
    | 1         | 50000     | 1     |
    | 2         | 45000     | 5     |
    | 3         | 100000    | 1     |
    | 4         | 20000     | 2     |
	When the order price is calculated and the result should be 321250.0