<template>
  <div>
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Работники</h6>
          <q-btn @click="addEmployee = true" v-if="isShowAddEmployeeBtn" size="sm" color="secondary" :icon="icons.mdiPlus" label="добавить работника" />
          <q-btn to="/human-resources/employees/create" size="sm" color="primary" :icon="icons.mdiPencil" label="создать работника" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="tin" :props="props">
            {{ props.row.tin }}
            <q-popup-edit
              v-model="props.row.tin"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.tin" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              v-model="props.row.name"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.name" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="position" :props="props">
            {{ props.row.position }}
            <q-popup-edit
              v-model="props.row.position"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.position" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="company" :props="props">
            {{ props.row.company }}
            <q-popup-edit
              v-model="props.row.company"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.company" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="salary" :props="props">
            {{ props.row.salary }}
            <q-popup-edit
              v-model="props.row.salary"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.salary" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="hiringDate" :props="props">
            {{ props.row.hiringDate }}
            <q-popup-edit
              v-model="props.row.hiringDate"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.hiringDate" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="phone" :props="props">
            {{ props.row.phone }}
            <q-popup-edit
              v-model="props.row.phone"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.hiringDate" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="email" :props="props">
            {{ props.row.email }}
            <q-popup-edit
              v-model="props.row.email"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.email" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.employeeId)" :loading="loading" />
            <q-btn class="q-ml-sm" color="secondary" size="sm" label="Просмотр" :to="'/human-resources/view/employee/' + props.row.employeeId" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="addPartner" v-if="isShowAddEmployeeBtn" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Добавление работника.</span>
        </q-card-section>

        <AddBankAccountPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

  </div>
</template>

<script>
import AddBankAccountPopup from 'components/addingElements/AddBankAccountPopup'
import icons from 'src/mixins/icons'

export default {
  name: 'EmployeesTable',
  components: {
    AddBankAccountPopup
  },
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => []
    },
    isShowAddEmployeeBtn: {
      type: Boolean,
      default: () => false
    }
  },
  methods: {
    saveChanges (partnerId) {
    },
    getPartner (partnerId) {
      this.$router.push('/partner/' + partnerId + '?tab=partnerInfo')
    }
  },
  data: () => {
    return {
      loading: false,
      addEmployee: false,
      columns: [
        { name: 'tin', label: 'ИНН', align: 'left', field: 'tin' },
        { name: 'name', label: 'Полное имя', field: 'name' },
        { name: 'position', label: 'Должность', field: 'position' },
        { name: 'company', label: 'Компания', field: 'company' },
        { name: 'salary', label: 'Зарплата', field: 'salary' },
        { name: 'hiringDate', label: 'Дата найма', field: 'hiringDate' },
        { name: 'phone', label: 'Телефон', field: 'phone' },
        { name: 'email', label: 'Email', field: 'email' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
