namespace EverydayLeetCode
{
    /// <summary>
    /// 2. 两数相加
    /// https://leetcode.cn/problems/add-two-numbers/description/
    /// </summary>
    class Solution_2 : IExcute
    {
        public void Excute()
        {
            ListNode listNode1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            ListNode listNode2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            //ListNode listNode1 = new ListNode(9);
            //ListNode listNode1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9
            //    , new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))))));

            //ListNode listNode2 = new ListNode(9, new ListNode(9, new ListNode(9)));
            ListNode result = AddTwoNumbers(listNode1, listNode2);
            while (result != null)
            {
                Console.WriteLine(result.val);  // 打印当前节点的val值
                result = result.next;         // 移动到下一个节点
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int a, b, sum, carry = 0;
            ListNode current = l1;
            do
            {
                a = current == null ? 0 : current.val;
                b = l2 == null ? 0 : l2.val;
                sum = a + b + carry;
                carry = sum / 10;

                if (current.next == null) // 在当前的下一个没有时才会需要去new一个
                {
                    if (l2 != null)
                    {
                        if (l2.next != null) // 另一列的下一个有值需要new
                            current.next = new ListNode();
                        else if (l2.next == null && carry == 1)// 另一列的下一个没值需要看是不是需要进一位，需要进以为才需要new
                        {
                            current.next = new ListNode(1);
                            carry = 0;
                        }
                    }
                    else
                    {
                        if (carry == 1) // 另一列已经空了，只有当前列有值，需要看最后一位是否需要进一位，需要则new
                        {
                            current.next = new ListNode(1);
                            carry = 0;
                        }
                    }
                }

                current.val = sum % 10;

                if (l2 != null)
                    l2 = l2.next;
                current = current.next;

            } while (current != null || l2 != null);
            return l1;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
