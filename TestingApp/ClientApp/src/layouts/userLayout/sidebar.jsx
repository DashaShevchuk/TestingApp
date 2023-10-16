import React,{useState} from "react";
import { Layout, Menu, Button, theme } from 'antd';
import { Link } from 'react-router-dom';
const { Header, Sider, Content } = Layout;
import {
    CheckCircleOutlined,
    MenuOutlined
  } from '@ant-design/icons';
const UserSidebar = () => {
  const [collapsed, setCollapsed] = useState(false);
  return (
    <React.Fragment>
      <Sider collapsible collapsed={collapsed} theme="light"  onCollapse={(value) => setCollapsed(value)} style={{height:"100vh"}}>
        <Menu theme="light" defaultSelectedKeys={['1']} mode="inline">
        <Menu.Item key="1" icon={<MenuOutlined />}>
          <Link to="/user/available">Available tests</Link>
        </Menu.Item>
        <Menu.Item key="2" icon={<CheckCircleOutlined />}>
          <Link to="/user/completed">Completed tests</Link>
        </Menu.Item>
      </Menu>
      </Sider>
    </React.Fragment>
  );
};
export default UserSidebar;