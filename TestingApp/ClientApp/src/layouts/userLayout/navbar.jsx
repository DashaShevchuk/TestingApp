import React from "react";
import { Layout, Menu, Button, theme } from 'antd';

const { Header, Sider, Content } = Layout;
import {
  LogoutOutlined
} from '@ant-design/icons';

const UserNavbar = (props) => {
  return (
    <React.Fragment>
      <Layout>
        <Header style={{ padding: 0, backgroundColor:'white', display:'flex', justifyContent:'flex-end', alignItems:'center', height:'7vh' }}>
          <Button icon={<LogoutOutlined />} type="primary" ghost onClick={(e) => props.onLogout(e)}>Logout</Button>
        </Header>
        </Layout>
    </React.Fragment>
  );
};
export default UserNavbar;
