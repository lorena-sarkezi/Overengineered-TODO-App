import Todos from "@/pages/Todos";
import Image from "next/image";

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between">
      <Todos />
    </main>
  );
}
