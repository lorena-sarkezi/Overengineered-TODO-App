import type { NextConfig } from "next";

const proxyConfig = async () => {
  return [
      {
        source: '/api/:path*',
        destination: 'http://localhost:52611/api/:path*',
        permanent: true,
      },
    ]
};

const nextConfig: NextConfig = {
  /* config options here */
  output: 'export',
  redirects: proxyConfig
};

export default nextConfig;
