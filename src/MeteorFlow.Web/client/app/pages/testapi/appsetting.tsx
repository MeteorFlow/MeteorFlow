import { useEffect, useState } from "react";
import { getSettings } from "../../services/appsettings";
import { AppSettings } from "../../models/settings";
import "./test.css";
import { EditOutlined } from "@ant-design/icons";
import FormSetting from "./form";

export default function AppSettingPage() {
  const [settings, setSettings] = useState<AppSettings[]>([]);
  const [showForm, setShowForm] = useState(false);
  const [edit, setEdit] = useState<AppSettings>();
  // const getDate = (date: Date | string | undefined) => {
  //   if (!date) {
  //     return '';
  //   }
  //   if (date instanceof Date) {
  //     return date.toDateString();
  //   }
  //   return date;
  // }

  const handleSubmit = async () => {
    setEdit(undefined);
    setShowForm(false);
    const data = await getSettings();
    if (data) setSettings(data);
  };

  useEffect(() => {
    async function fetchData() {
      const data = await getSettings();
      if (data) setSettings(data);
    }
    fetchData();
  }, []);
  
  // TODO: show data in table using antd
  return (
    <div style={{ display: "grid", gridTemplateColumns: "1fr 1fr", padding: "10px"}}>
      <div >
        <h1>Appsetting Page</h1>
        <div>
          <div
            style={{
              display: "flex-column",
              flexDirection: "column",
              paddingBottom: "10px",
            }}
          >
            <table>
              <thead>
                <tr>
                  <th>No.</th>
                  <th>Name</th>
                  <th>Value</th>
                  <th>Description</th>
                  <th>Type</th>
                </tr>
              </thead>
              {settings.map((setting, index) => (
                <tbody key={index}>
                  <tr>
                    <td style={{ textAlign: "center" }}>{index}</td>
                    <td>{setting.referenceKey}</td>
                    <td>{setting.value}</td>
                    <td>{setting.description}</td>
                    <td>{setting.type}</td>
                    <td style={{ paddingLeft: "10px", border: 'none' }}>
                      <button
                        className="button"
                        onClick={() => {
                          setEdit(setting);
                          setShowForm(true);
                        }}
                      >
                        <EditOutlined />
                      </button>
                    </td>
                  </tr>
                </tbody>
              ))}
            </table>
          </div>
          <div >
            <button className="button" onClick={() => setShowForm(true)}>
              Add Setting
            </button>
          </div>
        </div>
      </div>
      {showForm && (
        <FormSetting
          settings={edit}
          handleSubmit={handleSubmit}
          style={{ justifySelf: "center", alignSelf: "center" }}
        />
      )}
    </div>
  );
}
