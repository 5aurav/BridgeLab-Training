using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class SocialMediaFriends
    {
        class Friend
        {
            public int id;
            public Friend next;

            public Friend(int id)
            {
                this.id = id;
            }
        }

        class User
        {
            public int id;
            public string name;
            public int age;

            public Friend friends;
            public User next;

            public User(
                int id,
                string name,
                int age)
            {
                this.id = id;
                this.name = name;
                this.age = age;
            }
        }

        static User head;

        public static void Run()
        {
            head = null;

            AddUser(1, "Amit", 21);
            AddUser(2, "Riya", 22);
            AddUser(3, "Rahul", 21);
            AddUser(4, "Neha", 23);

            AddFriend(1, 2);
            AddFriend(1, 3);

            AddFriend(2, 1);
            AddFriend(2, 3);
            AddFriend(2, 4);

            AddFriend(3, 1);
            AddFriend(3, 2);

            Console.WriteLine("\nAmit's friends:");
            DisplayFriends(1);

            Console.WriteLine(
                "\nMutual friends of Amit and Riya:");

            MutualFriends(1, 2);

            Console.WriteLine("\nSearch user:");
            SearchUser("Riya");

            Console.WriteLine("\nFriend count:");
            FriendCount();

            RemoveFriend(1, 3);

            Console.WriteLine(
                "\nAfter removing Rahul from Amit's friends:");

            DisplayFriends(1);
        }

        static void AddUser(
            int id,
            string name,
            int age)
        {
            User n = new User(
                id,
                name,
                age);

            if (head == null)
            {
                head = n;
                return;
            }

            User temp = head;

            while (temp.next != null)
                temp = temp.next;

            temp.next = n;
        }

        static void AddFriend(
            int userId,
            int friendId)
        {
            User user = FindUser(userId);

            if (user == null)
                return;

            if (HasFriend(user, friendId))
                return;

            Friend n = new Friend(friendId);

            n.next = user.friends;
            user.friends = n;
        }

        static void RemoveFriend(
            int userId,
            int friendId)
        {
            User user = FindUser(userId);

            if (user == null)
                return;

            if (user.friends == null)
                return;

            if (user.friends.id == friendId)
            {
                user.friends = user.friends.next;
                return;
            }

            Friend temp = user.friends;

            while (temp.next != null)
            {
                if (temp.next.id == friendId)
                {
                    temp.next = temp.next.next;
                    return;
                }

                temp = temp.next;
            }
        }

        static void DisplayFriends(int userId)
        {
            User user = FindUser(userId);

            if (user == null)
                return;

            Friend temp = user.friends;

            while (temp != null)
            {
                User friend = FindUser(temp.id);

                if (friend != null)
                {
                    Console.WriteLine(
                        friend.id + " " +
                        friend.name);
                }

                temp = temp.next;
            }
        }

        static void MutualFriends(
            int id1,
            int id2)
        {
            User user1 = FindUser(id1);
            User user2 = FindUser(id2);

            if (user1 == null || user2 == null)
                return;

            Friend temp = user1.friends;

            while (temp != null)
            {
                if (HasFriend(user2, temp.id))
                {
                    User friend = FindUser(temp.id);

                    Console.WriteLine(
                        friend.name);
                }

                temp = temp.next;
            }
        }

        static void SearchUser(string name)
        {
            User temp = head;

            while (temp != null)
            {
                if (temp.name.Equals(
                    name,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                        temp.id + " " +
                        temp.name + " " +
                        temp.age);

                    return;
                }

                temp = temp.next;
            }

            Console.WriteLine("User not found");
        }

        static void SearchUser(int id)
        {
            User temp = head;

            while (temp != null)
            {
                if (temp.id == id)
                {
                    Console.WriteLine(
                        temp.id + " " +
                        temp.name + " " +
                        temp.age);

                    return;
                }

                temp = temp.next;
            }
        }

        static void FriendCount()
        {
            User temp = head;

            while (temp != null)
            {
                int count = 0;
                Friend f = temp.friends;

                while (f != null)
                {
                    count++;
                    f = f.next;
                }

                Console.WriteLine(
                    temp.name + " = " +
                    count);

                temp = temp.next;
            }
        }

        static bool HasFriend(
            User user,
            int friendId)
        {
            Friend temp = user.friends;

            while (temp != null)
            {
                if (temp.id == friendId)
                    return true;

                temp = temp.next;
            }

            return false;
        }

        static User FindUser(int id)
        {
            User temp = head;

            while (temp != null)
            {
                if (temp.id == id)
                    return temp;

                temp = temp.next;
            }

            return null;
        }
    }
}
