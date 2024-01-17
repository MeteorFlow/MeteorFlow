import { useState } from 'react';
import "./CategoryList.css";
import { ConfigProvider, MenuProps } from 'antd';
import { Menu } from 'antd';
import { CiApple } from "react-icons/ci";
import { IoFishOutline } from "react-icons/io5";
import { VscCoffee } from "react-icons/vsc";

import { AppstoreOutlined, MailOutlined, SettingOutlined } from '@ant-design/icons';
type MenuItem = Required<MenuProps>['items'][number];

function getItem(
    label: React.ReactNode,
    key: React.Key,
    icon?: React.ReactNode,
    children?: MenuItem[],
    type?: 'group',
  ): MenuItem {
    return {
      key,
      icon,
      children,
      label,
      type,
    } as MenuItem;
  }
  
  const items: MenuItem[] = [
    getItem('Fruits & Vegetables', 'sub1', <CiApple size={22}/>
    , [
      getItem('Fruits', '1'),
      getItem('Vegetables', '2'),
    ]),
    getItem('Meat & Fish', 'sub2', <IoFishOutline size={20}/>
    , [
      getItem('Fresh Fish', '3'),
      getItem('Meat', '4'),
    ]),
    getItem('Snacks', 'sub3', <VscCoffee size={20}/>, [
      getItem('Nuts & Biscuits', '5'),
      getItem('Chocolates', '6'),
      getItem('Crisps', '7'),
      getItem('Noodles & Pasta', '8'),
      getItem('Sauce', '9'),
      getItem('Soup', '10'),
    ]),
  ];
// submenu keys of first level
const rootSubmenuKeys = ['sub1', 'sub2', 'sub4'];

export const CategoryList: React.FC = () => {
    const [openKeys, setOpenKeys] = useState(['sub1']);

    const onOpenChange: MenuProps['onOpenChange'] = (keys) => {
      const latestOpenKey = keys.find((key) => openKeys.indexOf(key) === -1);
      if (latestOpenKey && rootSubmenuKeys.indexOf(latestOpenKey!) === -1) {
        setOpenKeys(keys);
      } else {
        setOpenKeys(latestOpenKey ? [latestOpenKey] : []);
      }
    };
    return (
        <div className="CategoryList">
          <ConfigProvider
            theme={{
                components: {
                  Menu: {
                    itemSelectedColor: '#009F7F',
                    itemHoverColor: '#009F7F',
                  },
                },
              }}
            >
              <Menu
              mode="inline"
              openKeys={openKeys}
              onOpenChange={onOpenChange}
              style={{ width: 256 }}
              items={items}
              />
            </ConfigProvider>
        </div>
    )
}

